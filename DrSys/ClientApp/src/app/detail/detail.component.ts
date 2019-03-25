import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent {
  public detail: drDetail[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<drDetail[]>(baseUrl + 'api/Doctor').subscribe(result => {
      this.detail = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface drDetail {
  name: string;
  gender: string;
  specName: string;
  averageRating: string;
}
