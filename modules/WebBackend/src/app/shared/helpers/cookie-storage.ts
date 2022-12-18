import { Injectable } from "@angular/core";
import Cookies from "universal-cookie";
import * as CryptoJS from "crypto-js";

@Injectable({
  providedIn: "root",
})
export class CookieStorage {
  private secrectKey = "secrectKey.process.Key";
  private options = { path: "/" };
  cookies = new Cookies();
  private encrypt(data: string) {
    try {
      if (!data) {
        return "";
      }

      const ciphertext = CryptoJS.AES.encrypt(data, this.secrectKey);
      return ciphertext.toString();
    } catch {
      return data;
    }
  }

  private decrypt(data: string) {
    if (!data) {
      return "";
    }

    const bytes = CryptoJS.AES.decrypt(data, this.secrectKey);
    const plaintext = bytes.toString(CryptoJS.enc.Utf8);
    return plaintext;
  }

  set(key: string, value: string, encrypted: boolean = false) {
    let newValue = value;
    if (encrypted) {
      newValue = this.encrypt(value);
    }
    this.cookies.set(key, newValue, { ...this.options });
  }

  get(key: string, decrypted: boolean = false) {
    if (decrypted) {
      return this.decrypt(this.cookies.get(key));
    }
    return this.cookies.get(key);
  }

  remove(key: string) {
    this.cookies.remove(key, { ...this.options });
  }
}
