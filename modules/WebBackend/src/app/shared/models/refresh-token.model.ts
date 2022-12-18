export class RefreshTokenModel{
    id: string;
    firstName: string;
    token: string;
    refreshToken: string;
    constructor(){
        this.id = '';
        this.firstName = '';
        this.token = '';
        this.refreshToken = '';
    }
}