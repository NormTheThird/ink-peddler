import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import * as uuidv4 from 'uuid/v4';
import * as aws from 'aws-sdk';
import 'rxjs/add/operator/map';
import { CONFIG } from '../app-config';

@Injectable()
export class AwsS3Provider {

  s3: aws.S3;

  constructor(public http: Http) {
    aws.config.region = CONFIG.AWSRegion;
    aws.config.accessKeyId = CONFIG.S3AccessKey; // TODO : Keys should be rotated
    aws.config.secretAccessKey = CONFIG.S3SecretAccessKey; // TODO : Keys should be rotated
    this.s3 = new aws.S3();
  }

  async uploadCoverImage(base64Image: string): Promise<string> {
    let imageKey = CONFIG.S3EnvKey() + CONFIG.S3CoverImageKey + uuidv4();
    return await this.uploadImage(imageKey, base64Image);
  }

  async uploadProfileImage(base64Image: string): Promise<string> {
    let imageKey = CONFIG.S3EnvKey() + CONFIG.S3ProfileImageKey + uuidv4();
    return await this.uploadImage(imageKey, base64Image);
  }

  async uploadTattooImage(base64Image: string): Promise<string> {
    let imageKey = CONFIG.S3EnvKey() + CONFIG.S3TattooImageKey + uuidv4();
    return await this.uploadImage(imageKey, base64Image);
  }

  private uploadImage(key: string, base64Image: string): Promise<string> {
    return new Promise((resolve, reject) => {
      try {
        let imageExtention = this.base64MimeType(base64Image);
        if (imageExtention === null) {
          reject("Unsupported File Type");
          return;
        }
        let imageData = this.dataURItoBlob(base64Image);
        this.s3.upload({
          Key: key,
          Body: imageData,
          Bucket: CONFIG.S3BucketName,
          ContentType: 'image/' + imageExtention
        }, function (err, data) {
          if (err) { throw err }
          resolve(key.split('/').pop());
        });
      } catch (err) {
        reject(null);
      }
    });
  }

  private dataURItoBlob(dataURI): Blob {
    try {
      let byteString = atob(dataURI.split(',')[1]);
      let mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0]
      let ab = new ArrayBuffer(byteString.length);
      let ia = new Uint8Array(ab);
      for (let i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
      }
      return new Blob([ab], { type: mimeString });
    } catch (e) {
      console.log(e);
    }
  }

  private base64MimeType(encoded) {
    var result = null;
    if (typeof encoded !== 'string') {
      return result;
    }
    var mime = encoded.match(/data:([a-zA-Z0-9]+\/[a-zA-Z0-9-.+]+).*,.*/);
    if (mime && mime.length) {
      result = mime[1];
    }
    if (result === "image/png") {
      return "png";
    } else if (result === "image/jpeg") {
      return "jpg";
    }
    return null;
  }

}
