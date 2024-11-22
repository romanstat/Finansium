import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { CountryService } from './country.service';
import { Country } from '../../../core/common.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-country',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './country.component.html',
  styleUrl: './country.component.scss',
})
export class CountryComponent implements OnInit {
  countryService = inject(CountryService);

  countries: Country[] = [];
  searchTerm: string = '';

  ngOnInit(): void {
    this.loadCountries();
  }

  search() {
    this.loadCountries();
  }

  loadCountries() {
    this.countryService.getAll(this.searchTerm).subscribe({
      next: (result) => {
        this.countries = result;
      },
    });
  }
}
