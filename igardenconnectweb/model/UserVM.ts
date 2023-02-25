export class UserVM {
    idUser?: number;
    login?: string;
    role?: string;
    password?: string;
  
    constructor(idUser?: number, login?: string, role?: string, password?: string) {
      this.idUser = idUser;
      this.login = login;
      this.role = role;
      this.password = password;
    }
  }