export class JwtToken {
    UserId: string;
    PhoneNumber?: string;
    Email: string;
    Role: string;
    nbf?: string;
    exp?: string;
    iat?: string;
    constructor() {
        this.UserId = '';
        this.PhoneNumber = '';
        this.nbf = '';
        this.exp = '';
        this.iat = '';
        this.Role = '';
        this.Email = '';
    }
}