import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Configuration } from '../app.constants';
import { map} from 'rxjs/operators';
@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private authUrl = '';
    constructor(private http: HttpClient, private _configuration: Configuration) {
        this.authUrl = _configuration.Server + 'token';
    }

    login(username: string, password: string) {
        var data = "grant_type=password&username=" + username + "&password=" + password;
        return this.http.post(this.authUrl, data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded'}})
            .pipe(map((res:any) => {
                // login successful if there's a jwt token in the response
                if (res && res.access_token) {
                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ username, token: res.access_token }));
                }
            }));
    }

 
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}