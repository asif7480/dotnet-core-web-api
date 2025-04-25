import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee',
  imports: [FormsModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
  employees: any[] = []

  employeeObj: any = {
    name: "",
    designation: ""
  }

  http = inject(HttpClient)
  constructor(){
    this.http.get("https://localhost:7148/api/Employee").subscribe( (response: any) => {
      console.log(response);
      this.employees = response;
    })
  }

  getEmployees(){
    try{
      this.http.get("https://localhost:7148/api/Employee").subscribe( (response: any) => {
        console.log(response)
        this.employees = response
      })
    }catch(err){
      console.log(`Error: ${err}`);
    }
  }

  addEmployee(){
    try{
      this.http.post(`https://localhost:7148/api/Employee`, this.employeeObj).subscribe( (response: any) => {
        alert("New employee added.")
        this.employees = response
        this.getEmployees();
      })
    }catch(err){
      console.log(`Error: ${err}`)
    }
  }
}
