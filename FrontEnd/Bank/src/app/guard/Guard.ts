import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  const token = localStorage.getItem("token");
  const userID = localStorage.getItem("userId");
  const roleName = localStorage.getItem("roleName");

  if (token && userID && roleName) {
    return true;
  }

  localStorage.removeItem("currSideBarTile");
  localStorage.removeItem("token");
  localStorage.removeItem("userId");
  localStorage.removeItem("roleName");
  router.navigate(['/login']);
  return false;
};
