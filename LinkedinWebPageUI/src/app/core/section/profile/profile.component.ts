import { Component, OnInit } from '@angular/core';
import { LinkedinWebPageService } from 'src/app/service/LinkedinWebPage.service';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Contact } from '../../models/contactModel';
import { Education } from '../../models/educationModel';
import { Experience } from '../../models/experienceModel';
import { User } from '../../models/user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  
  introductionModal=false
  contactModal=false
  editContactModal=false
  profile:User
  contact:Contact[]
  educations:Education[]
  education:Education
  experiences:Experience[]
  experience:Experience
  contactForm:FormGroup
  profileForm:FormGroup
  editedContact:Contact
  birthday
  user:User
  profileImage:File
 
  constructor(private linkedinService:LinkedinWebPageService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.linkedinService.getUserById(this.linkedinService.userID).subscribe(data=>{
      this.profile=data
      this.getEducation()
      this.getExperience()
      this.getContact()
    })

    this.editContactForm()
    this.editProfileForm()
  }

  editProfileForm(){
    this.profileForm=this.formBuilder.group({
    name: ["",Validators.required],
    surname: ["",Validators.required],
    position: ["",Validators.required],
    sector:["",Validators.required],
    country:["",Validators.required],
    city: ["",Validators.required],
    photo: ["",Validators.required]
    })
  }

  editContactForm(){
    this.contactForm=this.formBuilder.group({
      phoneNumber:["",Validators.required],
      phoneNumberType: ["",Validators.required],
      address: ["",Validators.required],
      birthday: ["",Validators.required]
    })
  }

  onFileSelect(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.profileImage=file
    }
  }

  getEducation(){
    this.linkedinService.getAllEducation().subscribe(data=>{
      this.educations=data.filter(x=>x.userId==this.profile.id)
      this.education=this.educations[0]
    })
  }

  getContact(){
    this.linkedinService.getAllContact().subscribe(data=>{
      this.contact=data.filter(x=>x.userId==this.profile.id)
    })
    this.birthday=this.contact[0].birthday
  }

  getExperience(){
    this.linkedinService.getAllExperience().subscribe(data=>{
      this.experiences=data.filter(x=>x.userId==this.profile.id)
      this.experience=this.experiences[0]
    })
  }

  updateContact(){
      this.editedContact=Object.assign({},this.contactForm.value)
      this.editedContact.id=this.contact[0].id
      this.editedContact.userId=this.profile.id
      this.linkedinService.updateContact(this.editedContact)
      this.birthday=this.editedContact.birthday
      setTimeout(() => {
        this.getContact()
      },
          1000);
    this.editContactModal=false
  }

  updateUser(){
      const userData={
        'name':this.profileForm.value.name,
        'surname':this.profileForm.value.surname,
        'position':this.profileForm.value.position,
        'country':this.profileForm.value.country,
        'city':this.profileForm.value.city,
        'photo':this.profile.photo,
        'id':this.profile.id,
        'emailAddress':this.profile.emailAddress
      }
      this.user=Object.assign({},userData)
      this.experience.sector=this.profileForm.value.sector
      this.linkedinService.updateUser(this.user); 
      this.imageUpload()
      this.linkedinService.updateExperience(this.experience)
      this.introductionModal=false
      // setTimeout(() => {
      //   this.ngOnInit()
      // },
      //     1000);
  }

  imageUpload(){
    const imageData={
      'id':this.profile.id,
      'image':this.profileImage,
    }
    const formData = new FormData();
    formData.append("image", this.profileImage);
    formData.append("id",this.profile.id.toString())
    this.linkedinService.uploadImage(formData)
  }

  openIntroductionModal(){
    this.introductionModal=!this.introductionModal
  }

  closeIntroductionModal(){
    this.introductionModal=false
  }

  openContactModal(){
    this.contactModal=true
  }

  closeContactModal(){
    this.contactModal=false
  }

  openEditContactModal(){
    this.editContactModal=true
  }

  closeEditContactModal(){
    this.editContactModal=false
  }
}
