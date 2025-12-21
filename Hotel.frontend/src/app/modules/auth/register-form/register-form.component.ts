
import { Router } from '@angular/router';


import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/auth/auth.service';

type FieldType = 'text' | 'email' | 'password' | 'select';
interface FormField {
  key: string;
  type: FieldType;
  label: string;
  placeholder?: string;
  required?: boolean;
  options?: { label: string; value: string }[];
  validators?: any[];
}



@Component({
  selector: 'app-register-form',
  standalone: false,
  templateUrl: './register-form.component.html'
})

export class RegisterFormComponent implements OnInit {
  activeTab: 'login' | 'register' = 'login';
  form!: FormGroup;
  isLoading = false;
  errorMsg: string | null = null;
  successMsg: string | null = null;

  // Konfiguracija polja za LOGIN
  readonly loginFields: FormField[] = [
    { key: 'loginEmail', type: 'email', label: 'Email', placeholder: 'Email', required: true,
      validators: [Validators.email] },
    { key: 'loginPassword', type: 'password', label: 'Šifra', placeholder: 'Šifra', required: true,
      validators: [Validators.minLength(8)] },
  ];

  // Konfiguracija polja za REGISTRACIJU
  readonly registerFields: FormField[] = [
    { key: 'firstName', type: 'text', label: 'Ime', placeholder: 'Ime', required: true },
    { key: 'lastName', type: 'text', label: 'Prezime', placeholder: 'Prezime', required: true },
    { key: 'address', type: 'text', label: 'Adresa', placeholder: 'Adresa', required: true },
    { key: 'city', type: 'text', label: 'Grad', placeholder: 'Grad', required: true },
    { key: 'state', type: 'text', label: 'Kanton', placeholder: 'Kanton', required: true },
    { key: 'zipCode', type: 'text', label: 'Poštanski broj', placeholder: 'Poštanski broj', required: true,
      validators: [Validators.pattern(/^[0-9]+$/)] },
    { key: 'country', type: 'text', label: 'Država', placeholder: 'Država', required: true },
    { key: 'phoneNumber', type: 'text', label: 'Telefon', placeholder: 'Telefon', required: true,
      validators: [Validators.pattern(/^[0-9+()\s-]+$/)] },
    { key: 'gender', type: 'select', label: 'Spol', placeholder: 'Odaberi spol', required: true,
      options: [
        { label: 'Muški', value: 'M' },
        { label: 'Ženski', value: 'F' },
      ]},
    { key: 'email', type: 'email', label: 'Email adresa', placeholder: 'Email adresa', required: true,
      validators: [Validators.email] },
    { key: 'password', type: 'password', label: 'Šifra', placeholder: 'Šifra (minimum 8 znakova)', required: true,
      validators: [Validators.minLength(8)] },
  ];

  // Trenutna lista polja prema aktivnom tabu
  currentFields: FormField[] = this.loginFields;

  constructor(private fb: FormBuilder, private router: Router, private auth: AuthService) {}

  ngOnInit(): void {
    this.buildForm(this.currentFields);
  }

  // Promjena taba
  setTab(tab: 'login' | 'register'): void {
    if (this.activeTab !== tab) {
      this.activeTab = tab;
      this.currentFields = tab === 'login' ? this.loginFields : this.registerFields;
      this.buildForm(this.currentFields);
      this.errorMsg = null;
      this.successMsg = null;
    }
  }

  // Kreiraj FormGroup iz konfiguracije
  private buildForm(fields: FormField[]): void {
    const group: Record<string, FormControl> = {};
    for (const f of fields) {
      const validators = [];
      if (f.required) validators.push(Validators.required);
      if (f.validators?.length) validators.push(...f.validators);
      group[f.key] = new FormControl('', validators);
    }
    this.form = this.fb.group(group);
  }

  // Submit (login/registracija)
  onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isLoading = true;
    this.errorMsg = null;
    this.successMsg = null;

    if (this.activeTab === 'login') {
      const payload = {
        email: this.form.value['loginEmail'],
        password: this.form.value['loginPassword'],
      };

      this.auth
        .login(payload)
        .then(() => {
          this.router.navigate(['/public']);
        })
        .catch((err) => {
          const msg = (err?.response?.data?.message as string) || 'Neispravan email ili šifra.';
          this.errorMsg = msg;
        })
        .finally(() => {
          this.isLoading = false;
        });
      return;
    }

    // Registracija - poziv backend API-ja
    const v = this.form.value;
    const registerPayload = {
      firstName: v['firstName'],
      lastName: v['lastName'],
      address: v['address'],
      city: v['city'],
      state: v['state'],
      zipCode: v['zipCode'],
      country: v['country'],
      phoneNumber: v['phoneNumber'],
      gender: v['gender'],
      email: v['email'],
      password: v['password'],
    };

    this.auth
      .register(registerPayload)
      .then((response) => {
        this.successMsg = 'Registracija uspješna! Možete se prijaviti.';
        this.form.reset();
        // Opciono: nakon par sekundi prebaci na login tab
        setTimeout(() => {
          this.setTab('login');
        }, 2000);
      })
      .catch((err) => {
        const msg = (err?.response?.data?.message as string) || 'Registracija nije uspjela. Pokušajte ponovo.';
        this.errorMsg = msg;
      })
      .finally(() => {
        this.isLoading = false;
      });
  }

  // Helper metode za provjeru validacije
  isFieldInvalid(fieldKey: string): boolean {
    const control = this.form.get(fieldKey);
    return !!(control && control.invalid && (control.dirty || control.touched));
  }

  getErrorMessage(fieldKey: string): string {
    const control = this.form.get(fieldKey);
    if (!control || !control.errors) return '';

    const field = this.currentFields.find(f => f.key === fieldKey);
    const label = field?.label || fieldKey;

    if (control.errors['required']) {
      return `${label} je obavezno polje.`;
    }
    if (control.errors['email']) {
      return 'Unesite ispravnu email adresu.';
    }
    if (control.errors['minlength']) {
      const minLength = control.errors['minlength'].requiredLength;
      return `${label} mora imati najmanje ${minLength} znakova.`;
    }
    if (control.errors['pattern']) {
      if (fieldKey === 'phoneNumber') {
        return 'Telefon mora sadržavati samo brojeve i znakove +, -, (), razmak.';
      }
      if (fieldKey === 'zipCode') {
        return 'Poštanski broj mora sadržavati samo brojeve.';
      }
    }
    return 'Nevažeća vrijednost.';
  }
}
