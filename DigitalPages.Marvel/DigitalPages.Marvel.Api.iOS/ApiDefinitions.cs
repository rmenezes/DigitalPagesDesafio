using System;
using Foundation;
using ObjCRuntime;

namespace DigitalPages.Marvel.Api.iOS
{
	// @interface Characters : NSObject
	[BaseType (typeof(NSObject))]
	interface Characters
	{
		// @property (nonatomic, strong) NSString * apiKey;
		[Export ("apiKey", ArgumentSemantic.Strong)]
		string ApiKey { get; set; }

		// @property (nonatomic, strong) NSString * apiUrl;
		[Export ("apiUrl", ArgumentSemantic.Strong)]
		string ApiUrl { get; set; }

		// @property (nonatomic, strong) NSString * ts;
		[Export ("ts", ArgumentSemantic.Strong)]
		string Ts { get; set; }

		// @property (nonatomic, strong) NSString * apiHash;
		[Export ("apiHash", ArgumentSemantic.Strong)]
		string ApiHash { get; set; }

		// -(id)initWithApiKey:(NSString *)apiKey andApiUrl:(NSString *)apiUrl andTs:(NSString *)ts andHash:(NSString *)hash;
		[Export ("initWithApiKey:andApiUrl:andTs:andHash:")]
		IntPtr Constructor (string apiKey, string apiUrl, string ts, string hash);

		// -(void)getAllWithName:(NSString *)name andCallback:(void (^)(NSString *))callback;
		[Export ("getAllWithName:andCallback:")]
		[Async]
		void GetAllWithName (string name, Action<NSString> callback);

		// -(void)getDetailsWith:(long)identifier andCallback:(void (^)(NSString *))callback;
		[Export ("getDetailsWith:andCallback:")]
		[Async]
		void GetDetailsWith (nint identifier, Action<NSString> callback);

		// -(void)getComicsWithIdCharacter:(long)idCharacter andCallback:(void (^)(NSString *))callback;
		[Export ("getComicsWithIdCharacter:andCallback:")]
		[Async]
		void GetComicsWithIdCharacter (nint idCharacter, Action<NSString> callback);
	}
}
