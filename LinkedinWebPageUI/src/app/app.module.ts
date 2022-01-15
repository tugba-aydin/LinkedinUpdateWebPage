import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { AboutComponent } from './core/section/about/about.component';
import { EditEducationComponent } from './core/section/education/editEducation/editEducation.component';
import { EducationComponent } from './core/section/education/education.component';
import { EditExperienceComponent } from './core/section/experience/editExperience/editExperience.component';
import { ExperienceComponent } from './core/section/experience/experience.component';
import { ProfileComponent } from './core/section/profile/profile.component';
import { EditSkillComponent } from './core/section/skill/editSkill/editSkill.component';
import { SkillComponent } from './core/section/skill/skill.component';
import { UpdateInformationComponent } from './pages/updateInformation/updateInformation.component';
import { webRoutes } from './Route';
import { ReactiveFormsModule, FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LinkedinWebPageService } from './service/LinkedinWebPage.service';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    UpdateInformationComponent,
    ProfileComponent,
    AboutComponent,
    ExperienceComponent,
    EducationComponent,
    SkillComponent,
    EditExperienceComponent,
    EditEducationComponent,
    EditSkillComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(webRoutes),
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [LinkedinWebPageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
