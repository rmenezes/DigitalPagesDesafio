//
//  ViewController.m
//  DigitalPages.Marvel
//
//  Created by Raul Menezes on 19/11/16.
//  Copyright © 2016 Raul Menezes. All rights reserved.
//

#import "ViewController.h"
#import <CommonCrypto/CommonDigest.h>

@interface ViewController ()


@end

Characters * serviceCharacter;

@implementation ViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    NSString *apiKey = @"";
    NSString *apiPrivateKey = @"";
    NSString *apiTs = @"";
    NSString *apiUrl = @"https://gateway.marvel.com:443/v1/public/characters";
    
    serviceCharacter = [[Characters alloc] initWithApiKey:apiKey andApiUrl:apiUrl andTs:apiTs andHash:[self md5:[NSString stringWithFormat:@"%@%@%@", apiTs, apiPrivateKey, apiKey]]];
}


- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
- (IBAction)BtGetById:(id)sender {
    [serviceCharacter getDetailsWith:[_TbSearch.text longLongValue] andCallback:^(NSString *callback) {
        [self showAlertWithJson:callback];
    }];
}

- (IBAction)BtGetData:(id)sender
{
    [serviceCharacter getAllWithName:[_TbSearch text] andCallback:^(NSString *callback) {
        [self showAlertWithJson:callback];
    }];
}
- (IBAction)BtGetComics:(id)sender {
    [serviceCharacter getComicsWithIdCharacter:[_TbSearch.text longLongValue] andCallback:^(NSString *callback) {
        [self showAlertWithJson:callback];
    }];
}

- (NSString *) md5:(NSString *) input
{
    const char *cStr = [input UTF8String];
    unsigned char digest[16];
    CC_MD5( cStr, strlen(cStr), digest ); // This is the md5 call
    
    NSMutableString *output = [NSMutableString stringWithCapacity:CC_MD5_DIGEST_LENGTH * 2];
    
    for(int i = 0; i < CC_MD5_DIGEST_LENGTH; i++)
        [output appendFormat:@"%02x", digest[i]];
    
    return  output;
    
}

- (void)showAlertWithJson:(NSString *)json
{
    NSRange range = {0, MIN([json length], 300)};
    range = [json rangeOfComposedCharacterSequencesForRange:range];
    NSString *shorMessage = [[NSString alloc]initWithFormat:@"%@ \r To see the full result check de output window.", [json substringWithRange:range]];
    
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Response Json from server" message:shorMessage preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:@"Thanks" style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
    }];
    
    [alert addAction:okAction];
    
    [self presentViewController:alert animated:YES completion:nil];
}

@end
