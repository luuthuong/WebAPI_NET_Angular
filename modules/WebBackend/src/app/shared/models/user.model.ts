export class UserModel {
    id: string;
    firstName: string;
    email: string;
    enabledEmailNotification: boolean;
    enabledSlackNotification: boolean;
    password?: string;
    createdDate?: Date;
    updatedDate?: Date;
    roles?: UserRoleModel[];
    constructor() {
        this.id = '';
        this.firstName = '';
        this.password = '';
        this.email = '';
        this.enabledEmailNotification = false;
        this.enabledSlackNotification = false;
        this.createdDate = new Date();
        this.updatedDate = new Date();
        this.roles = [];
    }
}


export class UserLoginModel {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
    token: string;
    refreshToken: string;
    httpStatusCode: number;
    errorMessage: string;
    roles: string[];
    constructor() {
        this.id = "";
        this.firstName = "";
        this.lastName = "";
        this.userName = "";
        this.token = "";
        this.refreshToken = "";
        this.httpStatusCode = 200;
        this.errorMessage = "";
        this.roles = [];
    }
}

export class UserRoleModel {
    id: string;
    name: string;
    constructor() {
        this.id = "";
        this.name = "";
    }
}


export class AuthenticatedUserModel {
    userId: string;
    firstName: string;
    lastName: string;
    // userName: string;
    email: string;
    roles: string[];

    constructor() {
        this.userId = '';
        this.firstName = '';
        this.lastName = '';
        // this.userName = '';
        this.email = '';
        this.roles = [];
    }
}