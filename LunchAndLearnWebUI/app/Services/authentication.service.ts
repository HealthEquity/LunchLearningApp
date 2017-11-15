import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import {Configuration } from '../app.constants';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    public token: string;
    private authUrl = '';
    constructor(private http: Http, private _configuration: Configuration) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
        this.authUrl = _configuration.Server + 'token';
    }

    login(username: string, password: string): Observable<boolean> {
        var data = "grant_type=password&username=" + username + "&password=" + password;
        return this.http.post(this.authUrl, data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let token = response.json() && response.json().access_token;
                if (token) {
                    // set token property
                    this.token = token;

                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));

                    // return true to indicate successful login
                    return true;
                } else {
                    // return false to indicate failed login
                    return false;
                }
            });
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }
}