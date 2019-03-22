import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent {
  public summary: drSummary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<drSummary[]>(baseUrl + 'api/Doctor').subscribe(result => {
      this.summary = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface drSummary {
  name: string;
  gender: string;
  specName: string;
  averageRating: string;
}
