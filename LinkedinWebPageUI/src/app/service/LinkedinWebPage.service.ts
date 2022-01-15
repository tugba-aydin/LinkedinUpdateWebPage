import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../core/models/contactModel';
import { User } from '../core/models/user';
import { Experience } from '../core/models/experienceModel';
import { Education } from '../core/models/educationModel';
import { Skill } from '../core/models/skillModel';
import { About } from '../core/models/aboutModel';

@Injectable({
  providedIn: 'root'
})
export class LinkedinWebPageService {

  constructor(private httpClient: HttpClient) { }
  userID=1
  userPath = "https://localhost:44346/User"
  contactPath = "https://localhost:44346/Contact"
  experiencePath = "https://localhost:44346/Experience"
  educationPath = "https://localhost:44346/Education"
  aboutPath= "https://localhost:44346/About"
  skillPath= "https://localhost:44346/Skill"

  getAllContact(): Observable<Contact[]> {
    return this.httpClient.get<Contact[]>(this.contactPath);
  }

  getAllEducation(): Observable<Education[]> {
    return this.httpClient.get<Education[]>(this.educationPath);
  }

  getAllExperience(): Observable<Experience[]> {
    return this.httpClient.get<Experience[]>(this.experiencePath);
  }

  getAllSkill():Observable<Skill[]>{
    return this.httpClient.get<Skill[]>(this.skillPath);
  }

  getAllAbout():Observable<About[]>{
    return this.httpClient.get<About[]>(this.aboutPath);
  }
  
  getContactById(contactId):Observable<Contact>{
    return this.httpClient.get<Contact>(`${this.contactPath}/${contactId}`)
  }

  getEducationById(educationId):Observable<Education>{
    return this.httpClient.get<Education>(`${this.educationPath}/${educationId}`)
  }

  getExperienceById(experienceId):Observable<Experience>{
    return this.httpClient.get<Experience>(`${this.experiencePath}/${experienceId}`)
  }

  getUserById(userId):Observable<User>{
    return this.httpClient.get<User>(`${this.userPath}/${userId}`)
  }

  getAboutById(aboutId):Observable<About>{
    return this.httpClient.get<About>(`${this.aboutPath}/${aboutId}`)
  }

  getSkillById(skillId):Observable<Skill>{
    return this.httpClient.get<Skill>(`${this.skillPath}/${skillId}`)
  }


  createContact(contact:Contact){
    this.httpClient.post(this.contactPath,contact).subscribe();
  }

  createEducation(education:Education){
    this.httpClient.post(this.educationPath,education).subscribe();
  }

  createExperience(experience:Experience){
    this.httpClient.post(this.experiencePath,experience).subscribe();
  }

  createSkill(skill:Skill){
    this.httpClient.post(this.skillPath,skill).subscribe();
  }

  updateContact(contact:Contact){
    return this.httpClient.put(this.contactPath,contact).subscribe();
  }

  updateEducation(education:Education){
    return this.httpClient.put(this.educationPath,education).subscribe();
  }

  updateExperience(experince:Experience){
    return this.httpClient.put(this.experiencePath,experince).subscribe();
  }

  updateUser(user:User){
    return this.httpClient.put(this.userPath,user).subscribe();
  }

  updateAbout(about:About){
    return this.httpClient.put(this.aboutPath,about).subscribe();
  }

  updateSkill(skill:Skill){
    return this.httpClient.put(this.skillPath,skill).subscribe();
  }

  deleteContact(contactId){
    return this.httpClient.delete(`${this.contactPath}/${contactId}`)
  }

  deleteEducation(educationId){
    return this.httpClient.delete(`${this.educationPath}/${educationId}`)
  }

  deleteExperience(experienceId){
    return this.httpClient.delete(`${this.experiencePath}/${experienceId}`)
  }

  deleteSkill(skillId){
    return this.httpClient.delete(`${this.skillPath}/${skillId}`)
  }

  uploadImage(imageData){
    return this.httpClient.post(this.userPath+"/ImageUpload",imageData).subscribe()
  }
}
