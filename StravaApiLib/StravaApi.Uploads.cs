using StravaApiLib.DTOs.Uploads;

namespace StravaApiLib
{
    public partial class StravaApi
    {
        /// <summary>
        /// Uploads an activity file. Requires activity:write.
        /// </summary>
        /// <param name="fileStream">The file stream to upload.</param>
        /// <param name="fileName">File name including extension (e.g. "activity.fit").</param>
        /// <param name="dataType">File format: "fit", "fit.gz", "tcx", "tcx.gz", "gpx", or "gpx.gz".</param>
        /// <param name="name">Optional activity name.</param>
        /// <param name="description">Optional activity description.</param>
        /// <param name="trainer">Set to "1" if this is a trainer activity.</param>
        /// <param name="commute">Set to "1" if this is a commute.</param>
        /// <param name="externalId">Optional external identifier to avoid duplicate uploads.</param>
        public async Task<UploadDto?> CreateUploadAsync(
            Stream fileStream,
            string fileName,
            string dataType,
            string? name = null,
            string? description = null,
            string? trainer = null,
            string? commute = null,
            string? externalId = null)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "file", fileName);
            content.Add(new StringContent(dataType), "data_type");
            if (name != null) content.Add(new StringContent(name), "name");
            if (description != null) content.Add(new StringContent(description), "description");
            if (trainer != null) content.Add(new StringContent(trainer), "trainer");
            if (commute != null) content.Add(new StringContent(commute), "commute");
            if (externalId != null) content.Add(new StringContent(externalId), "external_id");

            return await PostMultipartAsync<UploadDto>("uploads", content);
        }

        /// <summary>
        /// Returns the status of an upload. Poll this after <see cref="CreateUploadAsync"/> until
        /// <see cref="UploadDto.ActivityId"/> is set or <see cref="UploadDto.Error"/> is non-null.
        /// </summary>
        public async Task<UploadDto?> GetUploadAsync(long uploadId)
        {
            return await GetAsync<UploadDto>($"uploads/{uploadId}");
        }
    }
}
