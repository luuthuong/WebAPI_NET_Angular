import { Injectable } from "@angular/core";
import Cookies, { CookieSetOptions } from "universal-cookie";
import * as CryptoJS from 'crypto-js';
@Injectable({
    providedIn: 'root'
})
export class CookieStorage{
    private secretKey = 'secretKey.process.Key';
    private option: CookieSetOptions  = {
        path: '/'
    };
    cookies = new Cookies();
    constructor(){
        
    }

    private encrypt(data: string){
        try {
            if(!data){
                return '';
            }
            const ciphertext = CryptoJS.AES.encrypt(data, this.secretKey);
            return ciphertext.toString();
        } catch (_) {
            return data;
        }
    }

    private decrypt(data: string){
        if(!data){
            return '';
        }
        const bytes = CryptoJS.AES.decrypt(data , this.secretKey);
        const plaintext = bytes.toString(CryptoJS.enc.Utf8);
        return plaintext;
    }

    set(key: string, value: string, encrypted: boolean = false){
        this.cookies.set(key, encrypted ? this.encrypt(value) : value, this.option );
    }

    get(key: string, decrypted: boolean = false){
        return decrypted ? this.decrypt(this.cookies.get(key)) : this.cookies.get(key);
    }

    remove(key: string){
        this.cookies.remove(key, this.option);
    }
}