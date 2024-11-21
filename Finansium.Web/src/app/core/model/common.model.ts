export interface User {
  id: string;
  country: string;
  name: string;
  surname: string;
  patronymic: string;
  email: string;
  username: string;
  isBlocked: boolean;
  roles: Role[];
}

export interface Role {
  id: string;
  name: string;
}

export interface Country {
  id: string;
  shortName: string;
  fullName: string;
}
