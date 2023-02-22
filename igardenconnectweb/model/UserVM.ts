export class UserVM {
    idUser: number;
    name: string;
    login: string;
    role: string;
    password: string;
  
    constructor(idUser: number, name: string, login: string, role: string, password: string) {
      this.idUser = idUser;
      this.name = name;
      this.login = login;
      this.role = role;
      this.password = password;
    }
  }