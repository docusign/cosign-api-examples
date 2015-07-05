
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ErrorCode.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ErrorCode">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="malformedRequest"/>
 *     &lt;enumeration value="unsupportedOperation"/>
 *     &lt;enumeration value="unsupportedIdentifierType"/>
 *     &lt;enumeration value="noSuchIdentifier"/>
 *     &lt;enumeration value="customError"/>
 *     &lt;enumeration value="unsupportedExecutionMode"/>
 *     &lt;enumeration value="invalidContainment"/>
 *     &lt;enumeration value="noSuchRequest"/>
 *     &lt;enumeration value="unsupportedSelectionType"/>
 *     &lt;enumeration value="resultSetToLarge"/>
 *     &lt;enumeration value="unsupportedProfile"/>
 *     &lt;enumeration value="invalidIdentifier"/>
 *     &lt;enumeration value="alreadyExists"/>
 *     &lt;enumeration value="containerNotEmpty"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ErrorCode")
@XmlEnum
public enum ErrorCode {

    @XmlEnumValue("malformedRequest")
    MALFORMED_REQUEST("malformedRequest"),
    @XmlEnumValue("unsupportedOperation")
    UNSUPPORTED_OPERATION("unsupportedOperation"),
    @XmlEnumValue("unsupportedIdentifierType")
    UNSUPPORTED_IDENTIFIER_TYPE("unsupportedIdentifierType"),
    @XmlEnumValue("noSuchIdentifier")
    NO_SUCH_IDENTIFIER("noSuchIdentifier"),
    @XmlEnumValue("customError")
    CUSTOM_ERROR("customError"),
    @XmlEnumValue("unsupportedExecutionMode")
    UNSUPPORTED_EXECUTION_MODE("unsupportedExecutionMode"),
    @XmlEnumValue("invalidContainment")
    INVALID_CONTAINMENT("invalidContainment"),
    @XmlEnumValue("noSuchRequest")
    NO_SUCH_REQUEST("noSuchRequest"),
    @XmlEnumValue("unsupportedSelectionType")
    UNSUPPORTED_SELECTION_TYPE("unsupportedSelectionType"),
    @XmlEnumValue("resultSetToLarge")
    RESULT_SET_TO_LARGE("resultSetToLarge"),
    @XmlEnumValue("unsupportedProfile")
    UNSUPPORTED_PROFILE("unsupportedProfile"),
    @XmlEnumValue("invalidIdentifier")
    INVALID_IDENTIFIER("invalidIdentifier"),
    @XmlEnumValue("alreadyExists")
    ALREADY_EXISTS("alreadyExists"),
    @XmlEnumValue("containerNotEmpty")
    CONTAINER_NOT_EMPTY("containerNotEmpty");
    private final String value;

    ErrorCode(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ErrorCode fromValue(String v) {
        for (ErrorCode c: ErrorCode.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
