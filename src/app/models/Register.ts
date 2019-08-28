export class Register{
    Name:string;
    Surname:string;
    Username:string;
    Password:string;
    Gender:string;

    constructor(name:string,surname:string,username:string,password:string,gender:string)
    {
        this.Name=name;
        this.Surname=surname;
        this.Username=username;
        this.Password=password;
        this.Gender=gender;
    }
}