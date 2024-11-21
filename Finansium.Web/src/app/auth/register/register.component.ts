import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router, RouterOutlet } from '@angular/router';
import { Country } from '../../core/model/common.model';
import { CommonModule } from '@angular/common';
import { CountryService } from '../../modules/admin/country/country.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, RouterOutlet, CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  authService = inject(AuthService);
  router = inject(Router);
  countryService = inject(CountryService);

  countries: Country[] = [];

  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      countryId: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      patronymic: new FormControl(''),
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      retryPassword: new FormControl('', [Validators.required]),
    });
  }

  onSubmit() {
    if (!this.registerForm.valid) {
      return;
    }

    this.authService.register(this.registerForm.value).subscribe({
      next: () => {
        this.router.navigate(['login']);
      },
    });
  }

  ngOnInit(): void {
    this.countryService.getAll().subscribe({
      next: (countries) => {
        this.countries = countries;
      },
    });
  }
}
