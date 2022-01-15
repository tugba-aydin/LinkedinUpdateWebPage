import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';
import { About } from '../../models/aboutModel';
import { User } from '../../models/user';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  aboutModal = false
  abouts: About[]
  about: About
  profile: User
  editAboutForms: FormGroup
  editAboutModel:About

  constructor(private formBuilder: FormBuilder, private linkedinService: LinkedinWebPageService) { }

  ngOnInit() {

    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data => {
      this.profile = data;
      this.getAbout()
    })
    this.editAboutForm()
  }

  getAbout() {
    this.linkedinService.getAllAbout().subscribe(data => {
      this.abouts = data.filter(x => x.userId == this.profile.id)
      this.about = this.abouts[0]
    })
  }
  
  editAboutForm() {
    this.editAboutForms = this.formBuilder.group({
      aboutMe: ["", Validators.required]
    })
  }

  updateAbout(){
    if(this.editAboutForms.valid){
      this.editAboutModel=Object.assign({},this.editAboutForms.value)
      this.editAboutModel.id=this.about.id;
      this.editAboutModel.userId=this.about.userId
      this.linkedinService.updateAbout(this.editAboutModel);
      setTimeout(() => {
        this.getAbout()
      },
          1000);
    }
    this.aboutModal=false
  }

  openAboutModal() {
    this.aboutModal = true
  }

  closeAboutModal() {
    this.aboutModal = false
  }
}
