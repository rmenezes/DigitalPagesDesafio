//
//  Personagens.m
//  DigitalPages.Desafio
//
//  Created by Raul Menezes on 12/11/16.
//  Copyright © 2016 Raul Menezes. All rights reserved.
//

#import "Characters.h"
#import <AFNetworking/AFNetworking.h>

@implementation Characters

- (id)initWithApiKey: (NSString *)apiKey andApiUrl: (NSString *)apiUrl andTs: (NSString *)ts andHash: (NSString *)hash
{
    self = [super init];
    
    if(self) {
        _apiKey = apiKey;
        _apiUrl = apiUrl;
        _ts = ts;
        _apiHash = hash;
    }
    
    return self;
}

- (void)getAllWithName:(NSString *)name andCallback:(void (^)(NSString *))callback
{
    NSDictionary *parameters = @{@"apikey" : _apiKey,
                                 @"orderBy" : @"name",
                                 @"hash": _apiHash,
                                 @"ts" : _ts};
    
    
    if ([name length] > 1) {
        parameters = @{@"apikey" : _apiKey,
                       @"orderBy" : @"name",
                       @"hash": _apiHash,
                       @"ts" : _ts,
                       @"nameStartsWith" : name};
    }

    
    NSMutableURLRequest* request = [[AFHTTPRequestSerializer serializer]requestWithMethod:@"GET" URLString:_apiUrl parameters:parameters error:nil];
    
    NSURLSessionConfiguration *configuration = [NSURLSessionConfiguration defaultSessionConfiguration];
    AFURLSessionManager *manager = [[AFURLSessionManager alloc] initWithSessionConfiguration:configuration];
    
    NSURLSessionDataTask *dataTask = [manager dataTaskWithRequest:request completionHandler:^(NSURLResponse *response, id responseObject, NSError *error) {
        if (error) {
            NSLog(@"Error: %@", error);
        } else {
            NSDictionary *result = (NSDictionary *)responseObject;
            
            if(result) {
                NSDictionary *data = [result objectForKey:@"data"];
                
                if(data) {
                    NSDictionary *results = [data objectForKey:@"results"];
                    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:results options:NSJSONWritingPrettyPrinted error:&error];
                    
                    NSString *finalJson = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
                    
                    NSLog(@"%@", finalJson);
                    callback(finalJson);
                }
            }
        }
    }];
    
    [dataTask resume];
}

- (void)getDetailsWith:(long)identifier andCallback:(void (^)(NSString *))callback
{
    NSDictionary *parameters = @{@"apikey" : _apiKey,
                                 @"orderBy" : @"name",
                                 @"hash": _apiHash,
                                 @"ts" : _ts};
    
    NSString * formatedUrl = [NSString stringWithFormat:@"%@/%ld", _apiUrl, identifier];
    
    NSMutableURLRequest* request = [[AFHTTPRequestSerializer serializer]requestWithMethod:@"GET" URLString:formatedUrl parameters:parameters error:nil];
    
    NSURLSessionConfiguration *configuration = [NSURLSessionConfiguration defaultSessionConfiguration];
    AFURLSessionManager *manager = [[AFURLSessionManager alloc] initWithSessionConfiguration:configuration];
    
    NSURLSessionDataTask *dataTask = [manager dataTaskWithRequest:request completionHandler:^(NSURLResponse *response, id responseObject, NSError *error) {
        if (error) {
            NSLog(@"Error: %@", error);
        } else {
            NSDictionary *result = (NSDictionary *)responseObject;
            
            if(result) {
                NSDictionary *data = [result objectForKey:@"data"];
                
                if(data) {
                    NSDictionary *results = [data objectForKey:@"results"];
                    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:results options:NSJSONWritingPrettyPrinted error:&error];
                    
                    NSString *finalJson = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
                    
                    NSLog(@"%@", finalJson);
                    callback(finalJson);
                }
            }
        }
    }];
    
    [dataTask resume];
}

- (void)getComicsWithIdCharacter: (long)idCharacter andCallback: (void (^)(NSString *))callback
{
    NSDictionary *parameters = @{@"apikey" : _apiKey,
                                 @"orderBy" : @"title",
                                 @"hash": _apiHash,
                                 @"ts" : _ts,
                                 @"format" : @"comic",
                                 @"formatType" : @"comic",
                                 @"noVariants" : @"true"};
    
    NSString * formatedUrl = [NSString stringWithFormat:@"%@/%ld/comics", _apiUrl, idCharacter];
    
    NSMutableURLRequest* request = [[AFHTTPRequestSerializer serializer]requestWithMethod:@"GET" URLString:formatedUrl parameters:parameters error:nil];
    
    NSURLSessionConfiguration *configuration = [NSURLSessionConfiguration defaultSessionConfiguration];
    AFURLSessionManager *manager = [[AFURLSessionManager alloc] initWithSessionConfiguration:configuration];
    
    NSURLSessionDataTask *dataTask = [manager dataTaskWithRequest:request completionHandler:^(NSURLResponse *response, id responseObject, NSError *error) {
        if (error) {
            NSLog(@"Error: %@", error);
        } else {
            NSDictionary *result = (NSDictionary *)responseObject;
            
            if(result) {
                NSDictionary *data = [result objectForKey:@"data"];
                
                if(data) {
                    NSDictionary *results = [data objectForKey:@"results"];
                    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:results options:NSJSONWritingPrettyPrinted error:&error];
                    
                    NSString *finalJson = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
                    
                    NSLog(@"%@", finalJson);
                    callback(finalJson);
                }
            }
        }
    }];
    
    [dataTask resume];
}

@end
