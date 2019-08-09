import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  hasLogedIn(): boolean{
    if (localStorage.getItem('token')){
      return true;
    }
    else{
      return false;
    }
  }
}
