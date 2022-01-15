import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Experience } from '../../models/experienceModel';
import { User } from '../../models/user';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';


@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})

export class ExperienceComponent implements OnInit {
  experienceModal=false
  experiences:Experience[]
  profile:User
  addExperienceForms:FormGroup
  newExperience:Experience
  constructor(private router:Router,private linkedinService:LinkedinWebPageService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data=>{
      this.profile=data
      this.getExperiences()
    })
    this.addExperinceForm()
  }

  addExperinceForm(){
    this.addExperienceForms=this.formBuilder.group({
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

  getExperiences(){
    this.linkedinService.getAllExperience().subscribe(data=>{
      this.experiences=data.filter(x=>x.userId==this.profile.id)
    })
  }

  addNewExperience(){
    if(this.addExperienceForms.valid){
      this.newExperience=Object.assign({},this.addExperienceForms.value)
      this.newExperience.userId=this.profile.id
      this.linkedinService.createExperience(this.newExperience)
      setTimeout(() => {
        this.getExperiences()
      },
        1000);
    }
    this.experienceModal=false
  }

  openExperienceModal(){
    this.experienceModal=true
  }

  closeExperienceModal(){
    this.experienceModal=false
  }

  navigateEditExperience(){
    this.router.navigateByUrl("editExperience")
  }
}
