import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Education } from 'src/app/core/models/educationModel';
import { User } from 'src/app/core/models/user';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';

@Component({
  selector: 'app-editEducation',
  templateUrl: './editEducation.component.html',
  styleUrls: ['./editEducation.component.css']
})
export class EditEducationComponent implements OnInit {
  
  educationModal=false
  editEducationForms:FormGroup
  editEducation:Education
  profile:User
  educations:Education[]
  educationId
  editEducationByIdModel:Education
 
  constructor(private formBuilder:FormBuilder,private linkedinService:LinkedinWebPageService) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data=>{
      this.profile=data
      this.getEducations()
    })
    this.editEducationForm()
  }

  getEducations(){
    this.linkedinService.getAllEducation().subscribe(data=>{
     this.educations=data.filter(x=>x.userId==this.profile.id)
   })
 }

  editEducationForm(){
    this.editEducationForms=this.formBuilder.group({
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

  openSubEducationModal(ed){
    this.educationModal=true
    this.educationId=ed
    this.getEducationById()
  }

  getEducationById(){
    this.linkedinService.getEducationById(this.educationId).subscribe(data=>{
      this.editEducationByIdModel=data
    });
  }

  closeSubEducationModal(){
    this.educationModal=false
  }

  editedEducationForms(){
    if(this.editEducationForms.valid){
      this.editEducation=Object.assign({},this.editEducationForms.value)
      this.editEducation.id=this.editEducationByIdModel.id
      this.editEducation.userId=this.profile.id
      this.linkedinService.updateEducation(this.editEducation)
      setTimeout(() => {
        this.getEducations()
      },
          1000);
    }
    this.educationModal=false
  }

  deleteEducation(deleteEducationId){
    this.linkedinService.deleteEducation(deleteEducationId).subscribe();
    setTimeout(() => {
      this.getEducations()
    },
        1000);
    this.educationModal=false
  }
}
