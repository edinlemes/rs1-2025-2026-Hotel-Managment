
import { Router } from '@angular/router';


import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

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
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss'],
})

export class RegisterFormComponent implements OnInit {
  activeTab: 'login' | 'register' = 'login';
  form!: FormGroup;

  // Konfiguracija polja za LOGIN
  readonly loginFields: FormField[] = [
    { key: 'loginEmail', type: 'email', label: 'Email', placeholder: 'Email', required: true,
      validators: [Validators.email] },
    { key: 'loginPassword', type: 'password', label: 'Šifra', placeholder: 'Šifra', required: true,
      validators: [Validators.minLength(6)] },
  ];

  // Konfiguracija polja za REGISTRACIJU (zadržao sam tvoje IDs: regFirstName, regMail, ...)
  readonly registerFields: FormField[] = [
    { key: 'regFirstName', type: 'text',     label: 'Ime',              placeholder: 'Ime', required: true },
    { key: 'regLastName',  type: 'text',     label: 'Prezime',          placeholder: 'Prezime', required: true },
    { key: 'regAddress',   type: 'text',     label: 'Adresa',           placeholder: 'Adresa', required: true },
    { key: 'regCity',      type: 'text',     label: 'Grad',             placeholder: 'Grad', required: true },
    { key: 'regState',     type: 'text',     label: 'Kanton',           placeholder: 'Kanton', required: true },
    { key: 'regZip',       type: 'text',     label: 'Poštanski broj',   placeholder: 'Poštanski broj', required: true },
    { key: 'regCountry',   type: 'text',     label: 'Država',           placeholder: 'Država', required: true },
    { key: 'regPhone',     type: 'text',     label: 'Telefon',          placeholder: 'Telefon', required: true,
      validators: [Validators.pattern(/^[0-9+()\s-]{6,}$/)] },
    { key: 'regMail',      type: 'email',    label: 'Email adresa',     placeholder: 'Email adresa', required: true,
      validators: [Validators.email] },
    { key: 'regGender',    type: 'select',   label: 'Spol',             placeholder: 'Odaberi spol', required: true,
      options: [
        { label: 'Muški',  value: 'M' },
        { label: 'Ženski', value: 'F' },
      ]},
    { key: 'regUsername',  type: 'text',     label: 'Korisničko ime',   placeholder: 'Korisničko ime', required: true,
      validators: [Validators.minLength(3)] },
    { key: 'regPassword',  type: 'password', label: 'Šifra',            placeholder: 'Šifra (min 6)', required: true,
      validators: [Validators.minLength(6)] },
  ];

  // Trenutna lista polja prema aktivnom tabu
  currentFields: FormField[] = this.loginFields;

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.buildForm(this.currentFields);
  }

  // Promjena taba
  setTab(tab: 'login' | 'register'): void {
    if (this.activeTab !== tab) {
      this.activeTab = tab;
      this.currentFields = tab === 'login' ? this.loginFields : this.registerFields;
      this.buildForm(this.currentFields);
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

    if (this.activeTab === 'login') {
      const email = this.form.value['loginEmail'];
      // U tvom demo kodu samo setuješ "loggedIn"
      localStorage.setItem('loggedIn', 'true');
      // Preusmjeravanje (koristi Angular Router umjesto window.location.href)
      this.router.navigate(['/public']);
      return;
    }

    // Registracija – napravi objekat kao u tvom primjeru
    const v = this.form.value;
    const newUser = {
      FirstName: v['regFirstName'],
      LastName: v['regLastName'],
      Address: v['regAddress'],
      City: v['regCity'],
      State: v['regState'],
      ZipCode: v['regZip'],
      Country: v['regCountry'],
      PhoneNumber: v['regPhone'],
      MailAddress: v['regMail'], // kompatibilnost s tvojim nazivima
      Gender: v['regGender'],
      Username: v['regUsername'],
      Password: v['regPassword'],
      Email: v['regMail'],
      CreatedAt: new Date().toISOString(),
    };

    localStorage.setItem('loggedInUser', JSON.stringify(newUser));
    localStorage.setItem('loggedIn', 'true');
    this.router.navigate(['/public']);
  }
}
