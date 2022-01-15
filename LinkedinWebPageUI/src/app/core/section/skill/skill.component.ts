import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { User } from '../../models/user';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';
import { Skill } from '../../models/skillModel';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit {
  skillModal = false
  profile: User
  skills: Skill[]
  skillForm:FormGroup
  newSkill:Skill
  constructor(private router: Router, private linkedinService: LinkedinWebPageService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(x => {
      this.profile = x
      this.getSkills()
    })
    this.addSkillForm()
  }

  getSkills() {
    this.linkedinService.getAllSkill().subscribe(data => {
      this.skills = data.filter(x => x.userId == this.profile.id)
    })
  }

  addSkillForm(){
    this.skillForm=this.formBuilder.group({
      skillName:["",Validators.required]
    })
  }

  addNewSkill(){
    if(this.skillForm.valid){
      this.newSkill=Object.assign({},this.skillForm.value)
      this.newSkill.userId=this.profile.id
      this.linkedinService.createSkill(this.newSkill)
      setTimeout(() => {
        this.getSkills()
      },
          1000);
    }
    this.skillModal = false
  }

  openSkillModal() {
    this.skillModal = true
  }

  closeSkillModal() {
    this.skillModal = false
  }

  navigateEditSkill() {
    this.router.navigateByUrl("editSkill")
  }
}
