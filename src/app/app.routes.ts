import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "onboarding",
        pathMatch: "full"
    },
    {
        path: "onboarding",
        loadChildren: () => import('./pages/onboarding/onboarding.module').then(m => m.OnboardingModule)
    }
];
