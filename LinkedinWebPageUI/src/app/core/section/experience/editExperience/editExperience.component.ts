import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Experience } from 'src/app/core/models/experienceModel';
import { User } from 'src/app/core/models/user';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';

@Component({
  selector: 'app-editExperience',
  templateUrl: './editExperience.component.html',
  styleUrls: ['./editExperience.component.css']
})
export class EditExperienceComponent implements OnInit {
 
  experienceModal=false
  experiences:Experience[]
  profile:User
  editExperienceForms:FormGroup
  editExperience:Experience
  editExperienceByIdModel:Experience
  experienceId:number

  constructor(private linkedinService:LinkedinWebPageService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data=>{
      this.profile=data
      this.getExperiences()
    })
    this.editExperiencesForm()
  }

  getExperiences(){
    this.linkedinService.getAllExperience().subscribe(data=>{
      this.experiences=data.filter(x=>x.userId==this.profile.id)
    })
  }

  editExperiencesForm(){
    this.editExperienceForms=this.formBuilder.group({
      experienceTitle: ["",Validators.required],
      employmentType: ["",Validators.required],
      companyName: ["",Validators.required],
      location: ["",Validators.required],
      startDate: ["",Validators.required],
      endDate: ["",Validators.required],
      sector: [""],
      explanation: [""],
    })
  }

  openSubExperienceModal(ex){
    this.experienceModal=true
    this.experienceId=ex
    this.getExperienceById()
  }

  getExperienceById(){
    this.linkedinService.getExperienceById(this.experienceId).subscribe(data=>{
      this.editExperienceByIdModel=data
    })
  }

  closeSubExperienceModal(){
    this.experienceModal=false
  }

  editedExperience(){
    if(this.editExperienceForms.valid){
      this.editExperience=Object.assign({},this.editExperienceForms.value)
      this.editExperience.id=this.editExperienceByIdModel.id
      this.editExperience.userId=this.profile.id
      this.linkedinService.updateExperience(this.editExperience)
      setTimeout(() => {
        this.getExperiences()
      },
        1000);
    } 
    this.experienceModal=false
  }

  deleteExperience(deleteExperienceId){
    this.linkedinService.deleteExperience(deleteExperienceId).subscribe();
    setTimeout(() => {
      this.getExperiences()
    },
      1000);
    this.experienceModal=false
  }
}
