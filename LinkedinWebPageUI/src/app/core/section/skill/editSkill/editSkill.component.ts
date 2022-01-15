import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Skill } from 'src/app/core/models/skillModel';
import { User } from 'src/app/core/models/user';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';

@Component({
  selector: 'app-editSkill',
  templateUrl: './editSkill.component.html',
  styleUrls: ['./editSkill.component.css']
})
export class EditSkillComponent implements OnInit {
  
  skillModal= false;
  profile: User
  skills: Skill[]
  skillForm:FormGroup
  editSkill:Skill
  skillId
  editSkillById:Skill
  
  constructor(private linkedinService:LinkedinWebPageService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(x => {
      this.profile = x
      this.getSkills()
    })
    this.editSkillForm()
  }

  getSkills() {
    this.linkedinService.getAllSkill().subscribe(data => {
      this.skills = data.filter(x => x.userId == this.profile.id)
    })
  }

  editSkillForm(){
    this.skillForm=this.formBuilder.group({
      skillName:["",Validators.required]
    })
  }

  openSubSkillModal(sk){
    this.skillModal=true
    this.skillId=sk
    this.getSkillById()
  }

  getSkillById(){
    this.linkedinService.getSkillById(this.skillId).subscribe(data=>{
      this.editSkillById=data
    })
  }

  closeSubSkillModal(){
    this.skillModal=false
  }

  editedSkill(){
    if(this.skillForm.valid){
      this.editSkill=Object.assign({},this.skillForm.value)
      this.editSkill.id=this.editSkillById.id
      this.editSkill.userId=this.profile.id
      this.linkedinService.updateSkill(this.editSkill)
      setTimeout(() => {
        this.getSkills()
      },
          1000);
    } 
    this.skillModal=false
  }

  deleteSkill(deleteSkillId){
    this.linkedinService.deleteSkill(deleteSkillId).subscribe();
    setTimeout(() => {
      this.getSkills()
    },
        1000);
    this.skillModal=false
  }
}
