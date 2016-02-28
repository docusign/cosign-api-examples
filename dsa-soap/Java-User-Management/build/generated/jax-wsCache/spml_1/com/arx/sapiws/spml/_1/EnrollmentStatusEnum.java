
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for EnrollmentStatusEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="EnrollmentStatusEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="USER_ENROLLMENT_STATUS_DONT_CARE"/>
 *     &lt;enumeration value="USER_ENROLLMENT_STATUS_NONE"/>
 *     &lt;enumeration value="USER_ENROLLMENT_STATUS_NEW"/>
 *     &lt;enumeration value="USER_ENROLLMENT_STATUS_RENEW"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "EnrollmentStatusEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum EnrollmentStatusEnum {

    USER_ENROLLMENT_STATUS_DONT_CARE,
    USER_ENROLLMENT_STATUS_NONE,
    USER_ENROLLMENT_STATUS_NEW,
    USER_ENROLLMENT_STATUS_RENEW;

    public String value() {
        return name();
    }

    public static EnrollmentStatusEnum fromValue(String v) {
        return valueOf(v);
    }

}
