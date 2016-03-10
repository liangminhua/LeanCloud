using System;

namespace LeanCloud
{
    internal class Error
    {
        public int code { get; set; }
        public string error { get; set; }
        public AVException TOAVException() { return new AVException((AVException.ErrorCode)code, error); }
    }
    /// <summary>
    /// Exceptions that may occur when sending requests to LeanCloud.
    /// </summary>
    public class AVException : Exception
    {
        /// <summary>
        /// Error codes that may be delivered in response to requests to LeanCloud.
        /// </summary>
        public enum ErrorCode
        {
            OtherCause = -1,
            InternalServerError = 1,
            ConnectionFailed = 100,
            ObjectNotFound = 101,
            InvalidQuery = 102,
            InvalidClassName = 103,
            MissingObjectId = 104,
            InvalidKeyName = 105,
            InvalidPointer = 106,
            InvalidJSON = 107,
            CommandUnavailable = 108,
            NotInitialized = 109,
            IncorrectType = 111,
            InvalidChannelName = 112,
            PushMisconfigured = 115,
            ObjectTooLarge = 116,
            OperationForbidden = 119,
            CacheMiss = 120,
            InvalidNestedKey = 121,
            InvalidFileName = 122,
            InvalidACL = 123,
            Timeout = 124,
            InvalidEmailAddress = 125,
            MobilePhoneInvalid = 127,
            DuplicateValue = 137,
            InvalidRoleName = 139,
            ExceededQuota = 140,
            ScriptFailed = 141,
            UsernameMissing = 200,
            PasswordMissing = 201,
            UsernameTaken = 202,
            EmailTaken = 203,
            EmailMissing = 204,
            EmailNotFound = 205,
            SessionMissing = 206,
            MustCreateUserThroughSignup = 207,
            AccountAlreadyLinked = 208,
            CloudNotFindUser = 211,
            LinkedIdMissing = 250,
            InvalidLinkedSession = 251,
            UnsupportedService = 252,
            CurrentClientNetworkIsNotAvailable = 1001,
            CanNotSendMessageOnSessionNotOpen = 1002,
            ExceedMaximumLength = 4103,
            SessionNotOpen = 4105,
            HeartbeatTimeout = 4107,
            ConnectTimeout = 4108,
            MessageExceedMaximumSize = 4109,
            InternalError = 4200,
            ClientIdsCanNotBeNull = 4901
        }

        public ErrorCode Code { get; private set; }

        internal AVException(ErrorCode code, string message, Exception cause = null)
            : base(message, cause)
        {
            this.Code = code;
        }
    }
}