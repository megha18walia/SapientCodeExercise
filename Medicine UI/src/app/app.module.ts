import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { ViewmedicineComponent } from './Component/viewMedicine.component';
import { MedicineListComponent} from './Component/medicinelist.component';
import { DataService } from './Service/medicine.servie';


const routes: Routes = [
  { path: 'medicine', component: ViewmedicineComponent },
  { path: '', component: MedicineListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ViewmedicineComponent,
    MedicineListComponent
  ],
  imports: [
    BrowserModule, RouterModule.forRoot(routes), HttpClientModule,FormsModule
  ],
  exports: [RouterModule],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
