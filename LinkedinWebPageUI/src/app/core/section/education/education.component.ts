import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Education } from '../../models/educationModel';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';
import { User } from '../../models/user';


@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {
  educationModal=false
  addEducationForms:FormGroup
  educations:Education[]
  newEducation:Education
  profile:User

  constructor(private router:Router,private formBuilder:FormBuilder,private linkedinService:LinkedinWebPageService) { }

  ngOnInit() {

    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data=>{
      this.profile=data
      this.getEducations()
    })
    
    this.addEducationForm();

  }

  getEducations(){
     this.linkedinService.getAllEducation().subscribe(data=>{
      this.educations=data.filter(x=>x.userId==this.profile.id)
    })
  }

  addEducationForm(){
    this.addEducationForms=this.formBuilder.group({
    schoolName: ["", Validators.required],
    degree: ["", Validators.required],
    department: ["", Validators.required],
    startDate: ["", Validators.required],
    endDate: ["", Validators.required],
    note: ["", Validators.required],
    activitiesandCommunities: [""],
    explanation: [""]
    })
  }

  openEducationModal(){
    this.educationModal=true
  }

  closeEducationModal(){
    this.educationModal=false
  }

  navigateEditEducation(){
    this.router.navigateByUrl("editEducation")
  }

  addedEducation(){
    if(this.addEducationForms.valid){
      this.newEducation=Object.assign({},this.addEducationForms.value)
      this.newEducation.userId=this.profile.id
      this.linkedinService.createEducation(this.newEducation);
      setTimeout(() => {
        this.getEducations()
      },
          1000);
    }
    this.educationModal=false
  }
}
