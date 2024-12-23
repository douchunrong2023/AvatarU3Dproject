
#import <Foundation/Foundation.h>
#import "NativeCallProxy.h"


@implementation FrameworkLibAPI

id<NativeCallsProtocol> api = NULL;
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi
{
    api = aApi;
}

@end


extern "C" {

void iOSLog(const char * value);

}


void iOSLog(const char * value){
    
    return [api iOSLog:[NSString stringWithUTF8String:value]];
    
}


