declare module Api {
    // Models\BoundingBox.cs
    export interface BoundingBox {
        units: string;
        width: number;
        height: number;
        depth: number;
        pinX: number;
        pinY: number;
        pinZ: number;
    }

    // Models\ContextWrapper.cs
    export interface ISuccessOrFailure {
        Status: boolean;
        Message: string;
    }

    // Models\ContextWrapper.cs
    export interface Success extends ISuccessOrFailure {
        Status: boolean;
        Message: string;
    }

    // Models\ContextWrapper.cs
    export interface Failure extends ISuccessOrFailure {
        Status: boolean;
        Message: string;
    }

    // Models\ContextWrapper.cs
    export interface ContextWrapper<T> {
        dateTime: string;
        length: number;
        payloadType: String;
        payload: T[];
        hasError: boolean;
        message: string;
    }

    // Models\Extensions.cs
    export interface IoBTMath {
    }

    // Models\HighResPosition.cs
    export interface HighResPosition {
        units: string;
        xLoc: number;
        yLoc: number;
        zLoc: number;
        xAng: number;
        yAng: number;
        zAng: number;
    }

    // Models\KafkaMessage.cs
    export interface KafkaMessage {
        topic: string;
        data: any;
    }

    // Models\Location.cs
    export interface ILocation {
        lat: number;
        lng: number;
        alt: number;
    }

    // Models\Location.cs
    export interface Location extends UDTO_Base, ILocation {
        lat: number;
        lng: number;
        alt: number;
    }

    // Models\NameGenerator.cs
    export interface RandomName {
        rand: Random;
        First: string[];
        Last: string[];
    }

    // Models\UDTO_ActionStatus.cs
    export interface UDTO_ActionStatus extends UDTO_Base {
        status: string;
        message: string;
    }

    // Models\UDTO_Base.cs
    export interface UDTO {
    }

    // Models\UDTO_Base.cs
    export interface UDTO_Base {
        udtoTopic: string;
        sourceGuid: string;
        timeStamp: string;
        panID: string;
    }

    // Models\UDTO_Biometric.cs
    export interface UDTO_Biometric extends UDTO_Base {
        heartRate: number;
        temperature: number;
        stepCount: number;
        sleepScore: number;
        stressCalculation: number;
        fitnessScore: number;
    }

    // Models\UDTO_Body.cs
    export interface UDTO_Body extends UDTO_Base {
        uniqueGuid: string;
        bodyName: string;
        bodyType: string;
        symbol: string;
        platformName: string;
        data: string;
        position: HighResPosition;
        boundingBox: BoundingBox;
    }

    // Models\UDTO_Camera.cs
    export interface UDTO_Camera extends UDTO_Base {
        attributes: Record<string, any>;
        name: string;
        active: string;
        codec: string;
        url: string;
    }

    // Models\UDTO_ChatMessage.cs
    export interface UDTO_ChatMessage extends UDTO_Base {
        toUser: string;
        fromUser: string;
        message: string;
    }

    // Models\UDTO_Command.cs
    export interface UDTO_Command extends UDTO_Base {
        targetHashCode: string;
        command: string;
        args: string[];
    }

    // Models\UDTO_CommandResponse.cs
    export interface UDTO_CommandResponse extends UDTO_Command {
        response: string;
    }

    // Models\UDTO_CommunicationStatus.cs
    export interface UDTO_CommunicationStatus extends UDTO_Base {
        comType: string;
        strength: number;
        bandwidthUp: number;
        bandwidthDown: number;
        inUse: boolean;
        lastConnectionTime: string;
    }

    // Models\UDTO_Decision.cs
    export interface UDTO_Decision extends UDTO_Base {
        targetGuid: string;
        command: string;
        message: string;
    }

    // Models\UDTO_Direction.cs
    export interface UDTO_Direction extends UDTO_Base {
        speed: number;
        heading: number;
    }

    // Models\UDTO_Environment.cs
    export interface UDTO_Environment extends UDTO_Base {
        temperature: number;
        humidity: number;
        wind: UDTO_Direction;
    }

    // Models\UDTO_GridPosition.cs
    export interface UDTO_GridPosition extends UDTO_Position {
        gridCoordinates: string;
    }

    // Models\UDTO_Objective.cs
    export interface UDTO_Objective extends UniqueLocation {
        name: string;
        type: string;
        symbol: string;
        note: string;
    }

    // Models\UDTO_Observation.cs
    export interface UDTO_Observation extends UniqueLocation {
        target: string;
        range: number;
    }

    // Models\UDTO_Platform.cs
    export interface UDTO_Platform extends UDTO_Base {
        platformName: string;
        position: UDTO_Position;
        boundingBox: BoundingBox;
        members: UDTO_Body[];
    }

    // Models\UDTO_Position.cs
    export interface UDTO_Position extends Location {
    }

    // Models\UDTO_Sensor.cs
    export interface UDTO_Sensor extends UDTO_Base {
        type: string;
        name: string;
        active: string;
        extra: string;
        container: string;
    }

    // Models\UDTO_ServerSync.cs
    export interface UDTO_ServerSync {
        payload: string;
        command: string;
        history: string;
    }

    // Models\UDTO_ServerSync.cs
    export interface UDTO_PubSubSync extends UDTO_ServerSync {
        topic: string;
    }

    // Models\UDTO_SquireStatus.cs
    export interface UDTO_SquireStatus extends UDTO_Base {
        hostname: string;
        username: string;
        ipAddress: string;
        comStatus: UDTO_CommunicationStatus;
        gridPosition: UDTO_GridPosition;
        userBiometrics: UDTO_Biometric;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface IMUPoint {
        x: number;
        y: number;
        z: number;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface IMU {
        acceleratomer: IMUPoint;
        gyroscope: IMUPoint;
        magitometer: IMUPoint;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface UDTO_WeaponStatus extends UDTO_Base {
        currentAmmoCount: number;
        type: string;
        IMU: IMUPoint;
        targetDistance: number;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface UDTO_WeaponEvent extends UDTO_Base {
        gesture: string;
        message: string;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface UDTO_WeaponDefinition extends UDTO_Base {
        uniqueGuid: string;
        ammoCapacity: number;
        type: string;
        ammoType: string;
    }

    // Models\UDTO_WeaponStatus.cs
    export interface UDTO_VictorStatus extends UDTO_Base {
        batteryCharge: number;
        WeaponStatusCalculation: string;
        shotCount: number;
        lethalityScoreCalculation: number;
    }

    // Models\UniqueLocation.cs
    export interface UniqueLocation extends Location {
        uniqueGuid: string;
    }

}