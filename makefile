XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=/Users/raul/Projetos/DigitalPages/iOS/DigitalPages.Desafio
PROJECT=$(PROJECT_ROOT)/DigitalPages.Desafio.xcodeproj
PROJECT_FILES=$(PROJECT_ROOT)/DigitalPages.Desafio
PROJET_OUTPUT=/Users/raul/Projetos/DigitalPages
PROJET_FOLDER_OUTPUT=$(PROJET_OUTPUT)/DigitalPages.Marvel/DigitalPages.Marvel.Api.iOS/
NAMESPACE=DigitalPages.Marvel.Api.iOS
TARGET=UniversalLib
BINDING_PROJECT=DigitalPages.Marvel.iOS.Api

all: $(TARGET).framework

$(TARGET)-simulator.framework:
	$(XBUILD) ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	mv $(PROJECT_ROOT)/build/Release-iphonesimulator/$(TARGET).framework $(TARGET)-simulator.framework

$(TARGET)-iphone.framework:
	$(XBUILD) ONLY_ACTIVE_ARCH=NO -project $(PROJECT) -target $(TARGET) -sdk iphoneos -configuration Release clean build
	mv $(PROJECT_ROOT)/build/Release-iphoneos/$(TARGET).framework $(TARGET)-iphone.framework

$(TARGET).framework: $(TARGET)-simulator.framework $(TARGET)-iphone.framework $(BINDING_PROJECT)/Generated_ApiDefinitions.cs
	cp -R $(TARGET)-iphone.framework ./$(TARGET).framework
	rm ./$(TARGET).framework/$(TARGET)
	lipo -create -output $(TARGET).framework/$(TARGET) $(TARGET)-iphone.framework/$(TARGET) $(TARGET)-simulator.framework/$(TARGET)

sharpie:
	 sharpie bind --output=$(PROJET_FOLDER_OUTPUT) --namespace=$(NAMESPACE) --sdk=iphoneos10.1 $(PROJECT_FILES)/Characters.h

clean:
	rm -rf *.framework 