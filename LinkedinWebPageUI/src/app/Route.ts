import { Routes } from "@angular/router";
import { EditEducationComponent } from "./core/section/education/editEducation/editEducation.component";
import { EditExperienceComponent } from "./core/section/experience/editExperience/editExperience.component";
import { EditSkillComponent } from "./core/section/skill/editSkill/editSkill.component";
import { UpdateInformationComponent } from "./pages/updateInformation/updateInformation.component";

export const webRoutes: Routes = [
    { path: 'updateProfile', component: UpdateInformationComponent },
    { path: 'editExperience', component: EditExperienceComponent },
    { path: 'editEducation', component: EditEducationComponent },
    { path: 'editSkill', component: EditSkillComponent },
    { path: '', redirectTo: 'updateProfile', pathMatch: 'full' }
] 
