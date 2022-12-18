import { AppInjectorService } from "app/services/app-injector.service";
import { JwtToken } from "../models/jwt-token.model";
import { JwtHelperService } from "@auth0/angular-jwt";
import { AuthService } from "app/services/auth.service";
import decode from 'jwt-decode';

export class JWTHelper {
    static get parseJwt(): JwtToken {
        try {
            const injector = AppInjectorService.getInjector();
            const authService = injector.get(AuthService);
            const jwtToken = decode(authService.accessToken) as JwtToken;
            return jwtToken;
        } catch (_) {
            return new JwtToken();
        }
    }
}