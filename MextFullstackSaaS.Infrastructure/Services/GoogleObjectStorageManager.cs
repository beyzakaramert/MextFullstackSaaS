﻿using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MextFullstackSaaS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class GoogleObjectStorageManager : IObjectStorageService
    {
        private const string BucketName = "iconbuilderai-iconn-us";
        private readonly GoogleCredential _credential;

        public GoogleObjectStorageManager()
        {
            _credential = GoogleCredential.FromJson("C:\\Users\\beyza\\Desktop\\phrasal-descent-428107-t8-62ee50c59f1e.json");
        }

       

        public async Task<string> UploadImageAsync(string imageData, CancellationToken cancellationToken)
        {
            // Convert the base64 string to byte array
            var imageBytes = Convert.FromBase64String(imageData);

            // Create a new MemoryStream
            using var imageStream = new MemoryStream(imageBytes);

            // Create a new Google Cloud Storage client
            using var storage = await StorageClient.CreateAsync(_credential);

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid()}.jpg";

            // Upload the file to Google Cloud Storage
            var uploadedObject = await storage.UploadObjectAsync(
                BucketName,
                fileName,
                "image/jpeg",
                imageStream,
                cancellationToken: cancellationToken);

            // Return the public URL of the uploaded image
            //return $"https://storage.googleapis.com/{BucketName}/{fileName}";
            return fileName;

        }

        public async Task<List<string>> UploadImagesAsync(List<string> imagesData, CancellationToken cancellationToken)
        {
            var uploadTasks = imagesData.Select(imagesData => UploadImageAsync(imagesData, cancellationToken));

            var results = await Task.WhenAll(uploadTasks);

            return results.ToList();
        }

        public async Task<bool> RemoveAsync (string key, CancellationToken cancellationToken)
        {
            // Create a new Google Cloud Storage client
            using var storage = await StorageClient.CreateAsync(_credential);

           //Delete the file from Google Cloud Storage
           await storage.DeleteObjectAsync(BucketName, key, cancellationToken: cancellationToken);

            return true;
        }

        public async Task<bool> RemoveAsync(List<string> keys, CancellationToken cancellationToken)
        {
            // Create a new Google Cloud Storage client
            using var storage = await StorageClient.CreateAsync(_credential);

            //Delete the file from Google Cloud Storage
            var deleteTasks = keys
                .Select(key => storage.DeleteObjectAsync(BucketName, key, cancellationToken: cancellationToken));
            await Task.WhenAll(deleteTasks);
            return true;

        }


    }
    }

