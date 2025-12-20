import { RegularExpressionLiteral } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-form',
  standalone: false,
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss'],
})
export class RegisterFormComponent implements OnInit {

  ngOnInit(): void {
    const tabLogin = document.getElementById("tabLogin");
    const tabRegister = document.getElementById("tabRegister");
    const loginForm = document.getElementById("loginForm");
    const registerForm = document.getElementById("registerForm");

    tabLogin?.addEventListener("click", () => {
      loginForm?.classList.remove("hidden");
      registerForm?.classList.add("hidden");
      tabLogin?.classList.add("active");
      tabRegister?.classList.remove("active");
    });

    tabRegister?.addEventListener("click", () => {
      registerForm?.classList.remove("hidden");
      tabRegister?.classList.add("active");
      loginForm?.classList.add("hidden");
      tabLogin?.classList.remove("active");
    });
  }

}
