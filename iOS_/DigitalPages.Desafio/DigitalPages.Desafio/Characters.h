//
//  Personagens.h
//  DigitalPages.Desafio
//
//  Created by Raul Menezes on 12/11/16.
//  Copyright © 2016 Raul Menezes. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Characters : NSObject

@property (nonatomic,strong) NSString* apiKey;
@property (nonatomic,strong) NSString* apiUrl;
@property (nonatomic,strong) NSString* ts;
@property (nonatomic,strong) NSString* apiHash;

- (id)initWithApiKey: (NSString *)apiKey andApiUrl: (NSString *)apiUrl andTs: (NSString *)ts andHash: (NSString *)hash;
- (void)getAllWithName:(NSString *)name andCallback:(void (^)(NSString *))callback;
- (void)getDetailsWith: (long)identifier andCallback: (void (^)(NSString *))callback;
- (void)getComicsWithIdCharacter: (long)idCharacter andCallback: (void (^)(NSString *))callback;

@end
