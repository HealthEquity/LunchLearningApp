import { Injectable } from '@angular/core';
 
// @Injectable()
export class Configuration {
    public Server: string = "http://localhost:8748/";
    public ApiUrl: string = "api/";
    public ServerWithApiUrl = this.Server + this.ApiUrl;
}

// export class Configuration {
//     public Server: string = "http://lunchandlearn-api.healthequity.com/";
//     public ApiUrl: string = "api/";
//     public ServerWithApiUrl = this.Server + this.ApiUrl;
// }