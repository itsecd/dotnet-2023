/* 
 * RentalService.Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// RentalInformation
    /// </summary>
    [DataContract]
    public partial class RentalInformation :  IEquatable<RentalInformation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalInformation" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="rentalPointId">rentalPointId.</param>
        /// <param name="rentalDate">rentalDate.</param>
        /// <param name="rentalPeriod">rentalPeriod.</param>
        /// <param name="issuedCarId">issuedCarId.</param>
        public RentalInformation(long id = default(long), long rentalPointId = default(long), DateTime rentalDate = default(DateTime), long rentalPeriod = default(long), long? issuedCarId = default(long?))
        {
            this.IssuedCarId = issuedCarId;
            this.Id = id;
            this.RentalPointId = rentalPointId;
            this.RentalDate = rentalDate;
            this.RentalPeriod = rentalPeriod;
            this.IssuedCarId = issuedCarId;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets RentalPointId
        /// </summary>
        [DataMember(Name="rentalPointId", EmitDefaultValue=false)]
        public long RentalPointId { get; set; }

        /// <summary>
        /// Gets or Sets RentalDate
        /// </summary>
        [DataMember(Name="rentalDate", EmitDefaultValue=false)]
        public DateTime RentalDate { get; set; }

        /// <summary>
        /// Gets or Sets RentalPeriod
        /// </summary>
        [DataMember(Name="rentalPeriod", EmitDefaultValue=false)]
        public long RentalPeriod { get; set; }

        /// <summary>
        /// Gets or Sets IssuedCarId
        /// </summary>
        [DataMember(Name="issuedCarId", EmitDefaultValue=true)]
        public long? IssuedCarId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RentalInformation {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RentalPointId: ").Append(RentalPointId).Append("\n");
            sb.Append("  RentalDate: ").Append(RentalDate).Append("\n");
            sb.Append("  RentalPeriod: ").Append(RentalPeriod).Append("\n");
            sb.Append("  IssuedCarId: ").Append(IssuedCarId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RentalInformation);
        }

        /// <summary>
        /// Returns true if RentalInformation instances are equal
        /// </summary>
        /// <param name="input">Instance of RentalInformation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RentalInformation input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.RentalPointId == input.RentalPointId ||
                    (this.RentalPointId != null &&
                    this.RentalPointId.Equals(input.RentalPointId))
                ) && 
                (
                    this.RentalDate == input.RentalDate ||
                    (this.RentalDate != null &&
                    this.RentalDate.Equals(input.RentalDate))
                ) && 
                (
                    this.RentalPeriod == input.RentalPeriod ||
                    (this.RentalPeriod != null &&
                    this.RentalPeriod.Equals(input.RentalPeriod))
                ) && 
                (
                    this.IssuedCarId == input.IssuedCarId ||
                    (this.IssuedCarId != null &&
                    this.IssuedCarId.Equals(input.IssuedCarId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.RentalPointId != null)
                    hashCode = hashCode * 59 + this.RentalPointId.GetHashCode();
                if (this.RentalDate != null)
                    hashCode = hashCode * 59 + this.RentalDate.GetHashCode();
                if (this.RentalPeriod != null)
                    hashCode = hashCode * 59 + this.RentalPeriod.GetHashCode();
                if (this.IssuedCarId != null)
                    hashCode = hashCode * 59 + this.IssuedCarId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
