
#import <Foundation/Foundation.h>
@protocol NativeCallsProtocol

@required



- (void)iOSLog:(NSString *)value;


@end

__attribute__ ((visibility("default")))

@interface FrameworkLibAPI : NSObject
// call it any time after UnityFrameworkLoad to set object implementing NativeCallsProtocol methods
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi;

@end


