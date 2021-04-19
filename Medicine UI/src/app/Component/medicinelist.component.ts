import { Component } from '@angular/core';
import { DataService } from '../Service/medicine.servie';
declare var $: any;
declare var moment: any;


@Component({
  selector: 'app-root',
  templateUrl: './medicinelist.component.html',
  styleUrls: ['./medicinelist.component.css']
})
export class MedicineListComponent {
  title = '';
  showModal: boolean;
  content: string;

  constructor(private dataService: DataService) { }

  medicines=[];

  filteredMedicine = this.medicines;
  
  addNew(mName,mBrand,mQuantity,mExpiry,mprice, mnotes){
    this.dataService.sendSaveRequest(
      {name: mName, 
      brand: mBrand, 
      quantity: parseInt(mQuantity), 
      price : parseInt(mprice), 
      expiryDate: new Date(mExpiry), 
      notes:mnotes }).subscribe((response: any[])=>{
      this.getMedicines();
      this.hide();
    });
  }
 
  search(value){
    if(value){
    this.filteredMedicine = this.medicines.filter( function(medicine) { return medicine.name.toLowerCase().indexOf(value.toLowerCase())>-1; });
    }
    else {
      this.filteredMedicine = this.medicines;
    }
  }

  navigate(id){
    window.location.href = '/medicine?id='+ id;
  }
  
  public ngOnInit()
  {
   $("#datetimepicker1").datetimepicker();
   this.getMedicines();
  }

show()
{
  this.showModal = true; 
  this.title = "Add Medicine"; 
}

hide()
{
  this.showModal = false;
}

getMedicines(){
  this.dataService.sendGetRequest().subscribe((data: any[])=>{
    this.medicines = data;
    this.filteredMedicine = this.medicines;
  }) 
}

getFormattedDate(date){
  return  moment(date).format('MM/DD/YYYY');;
}

getDateDifference(date1){
  var startDate = moment(date1);
  var endDate = moment(new Date());
  return endDate.diff(startDate, 'days');
}
}
