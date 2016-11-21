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

		// -(void)getAllWithCallback:(void (^)(id))callback;
		[Export ("getAllWithCallback:")]
		void GetAllWithCallback (Action<NSObject> callback);

		// -(void)getDetailsWith:(int)identifier andCallback:(void (^)(id))callback;
		[Export ("getDetailsWith:andCallback:")]
		void GetDetailsWith (int identifier, Action<NSObject> callback);
	}
}
