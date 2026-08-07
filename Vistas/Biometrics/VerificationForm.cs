using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Proyecto_Grupo2.Modelos;

namespace Enrollment
{
	/* NOTE: This form is inherited from the CaptureForm,
		so the VisualStudio Form Designer may not load it properly
		(at least until you build the project).
		If you want to make changes in the form layout - do it in the base CaptureForm.
		All changes in the CaptureForm will be reflected in all derived forms 
		(i.e. in the EnrollmentForm and in the VerificationForm)
	*/
	public class VerificationForm : CaptureForm
	{
		public event Action<bool> VerificationCompleted;
		public event Action<AuthUser, bool> IdentificationCompleted;

		public void Verify(DPFP.Template template)
		{
			Template = template;
			ShowDialog();
		}

		public void Identify(IEnumerable<AuthUser> users)
		{
			Candidates = users == null ? new List<AuthUser>() : users.ToList();
			ShowDialog();
		}

		protected override void Init()
		{
			base.Init();
			base.Text = "Fingerprint Verification";
			Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
			UpdateStatus(0);
		}

		protected override void Process(DPFP.Sample Sample)
		{
			base.Process(Sample);

			// Process the sample and create a feature set for the enrollment purpose.
			DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

			// Check quality of the sample and start verification if it's good
			// TODO: move to a separate task
			if (features != null)
			{
				if (Candidates == null)
				{
					DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
					Verificator.Verify(features, Template, ref result);
					UpdateStatus(result.FARAchieved);
					if (result.Verified)
					{ MakeReport("The fingerprint was VERIFIED."); BeginInvoke(new Action(() => { VerificationCompleted?.Invoke(true); Close(); })); }
					else MakeReport("The fingerprint was NOT VERIFIED.");
				}
				else
				{
					AuthUser matched = null;
					foreach (var candidate in Candidates)
					{
						try
						{
							var candidateTemplate = new DPFP.Template(new System.IO.MemoryStream(candidate.Template));
							var result = new DPFP.Verification.Verification.Result();
							Verificator.Verify(features, candidateTemplate, ref result);
							UpdateStatus(result.FARAchieved);
							if (result.Verified) { matched = candidate; break; }
						}
						catch (Exception) { }
					}
					if (matched != null) MakeReport("The fingerprint was VERIFIED.");
					else MakeReport("The fingerprint was NOT VERIFIED.");
					BeginInvoke(new Action(() => { IdentificationCompleted?.Invoke(matched, matched != null); Close(); }));
				}
			}
		}

		private void UpdateStatus(int FAR)
		{
			// Show "False accept rate" value
			SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
		}

		private DPFP.Template Template;
		private DPFP.Verification.Verification Verificator;
		private List<AuthUser> Candidates;

	}
}
