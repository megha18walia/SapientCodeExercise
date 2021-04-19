import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class DataService {

  private GET_MEDICINES_URI = "https://medicineapiplan.azurewebsites.net/api/Medicine/GetMedicines";
  private SAVE_MEDICINE_URI = "https://medicineapiplan.azurewebsites.net/api/Medicine/SaveMedicine";
  private GET_MEDICINEBY_ID = "https://medicineapiplan.azurewebsites.net/api/Medicine/GetMedicinesByID/"
  

  constructor(private httpClient: HttpClient) { }

  public sendGetRequest(){
    return this.httpClient.get(this.GET_MEDICINES_URI);
  }

  public sendSaveRequest(medicine){
      console.log(medicine);
    return this.httpClient.post(this.SAVE_MEDICINE_URI, medicine);
  }

  public getMedicineById(id){
    return this.httpClient.get(this.GET_MEDICINEBY_ID + id);
  }
}

