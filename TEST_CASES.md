##VersionOne Integration for JIRA Sync 6.4 Test Cases

The test cases outlined in this document are for verifying that the installation, configuration, and primary workflows of the VersionOne Integration for JIRA Sync function as expected.  These test cases are by no means comprehensive, but essentially serve as a "smoke test" of the integration.

### Test Case 1: Verify Documentation

Step 1. Open documentation at http://versionone.github.io.VersionOne.Integration.JIRA/  
Step 2. Verify that system requirements are accurate.  
> Expected result: Documentation contains all pertinent system requirements.  

Step 3. Verify installation steps.  
Step 4. Verify screenshots.  
> Expected result: Screenshots should match what user will see during installation and completing workflow tasks.  

Step 5. Verify usage workflows.  
> Expected result: VersionOne and JIRA workflows produce desired work item tracking and visibility within VersionOne.  

### Test Case 2: Verify V1 JIRA Integration Installation  
*Assumption: JIRA is already installed, configured and running properly.*

Step 1. Determine install location for the integration; the integration can be installed on any server with network access to both V1 and JIRA. 
Step 2. Download and extract the latest version of V1 JIRA Integration into a folder of your choice.    

>Expected result: In the folder you chose to extract the integration files to, you should see a bin folder, a doc folder, a LICENSE.md file and a README.md file.   

### Test Case 3: Configure JIRA
Step 1. Select or create a new JIRA user that has rights to accept work, create, modify, and close Issues.
>Expected result: Specified JIRA user is assigned the Developer Role or higher on the project.  
Step 2. Decide on an integration methodology: Assigned, Labeled, Type and Status, or Tagged Issues.

### Test Case 3A: User Assigned Issues by Type and Status
Step 1. All new Issues created in JIRA must be assigned to the user specified above. A separate Saved Filter should be created for a V1 Story and a V1 Defect with the desired JIRA status(es) to be pulled into V1 (e.g. All Bugs in Status Open with Assignee V1Tester).
Step 2. Create a Saved Filter in JIRA for a Bug Issue type and status of OPEN assigned to the specified user.
Step 3. Run that Saved Filter to verify that only Bug Issue types with a status of OPEN are retrieved for the specified user.
>Expected result: Filter returns any and all Bugs with OPEN status that are assigned to the specified JIRA user. 

### Test Case 3B: Labeled Issues 
Step 1. In order to use a Labeled Saved Filter, first an Issue must be created with the desired Label value.  
>Expected result: A JIRA Issue exists with the value of "VersionOne" in the Label field.  

Step 2. Create a Saved Filter in JIRA specifying the desired Issue type(s) that will become V1 Stories and the Label field with the value of "VersionOne".  
Step 3. Run that Saved Filter.  
>Expected result: The Saved Filter returns any and all Issues of the specified type(s) with the value "VersionOne" in the Label field.  

### Test Case 3C: Type and Status Issues  
Step 1. Create new Issues in JIRA of a certain Type and Status (e.g. All Bugs in Status Open) to be moved to V1.  
Step 2. Create a Saved Filter in JIRA specifying the Issue Type and Status as criteria.  
Step 3. Run that Saved Filter.  
>Expected result: Filter returns any and all Issues of that Type and Status.  

### Test Case 3D: Tagged Issues using JIRA Custom Field 
Step 1. Create a new Custom Field in JIRA.    
>Expected result: JIRA now contains a custom field named "v1Field" (or any custom name you determine), with a description value of "V1" (or any custom value you determine for your project or organization).  
  
Step 2. All new Issues of a certain type and status created in JIRA must be saved with this new custom created field set to the "V1" value.    
Step 3. Create a Saved Filter in JIRA using the new Custom Field and value.  
Step 4. Run that Saved Filter.  
>Expected result: The Saved Filter returns any and all Issues that contain the Custom Field and value.    

### Test Case 4A: VersionOne Asset URL in JIRA Issue Comment  
By default, the integration will place the V1 Defect URL in the JIRA Issue Comments field.  
Step 1. After an Issue has been created in JIRA and integrated with V1, open the Issue in JIRA and inspect the Comments field for the V1 URL.  
Step 2. Click on that URL.  
>Expected result: The created Defect or Story opens in V1.  

### Test Case 4B: VersionOne Asset URL in JIRA Custom Field
Step 1. Create a Custom Field in JIRA for the V1 Defect URL.  
>Expected result: JIRA contains a Custom Field named "VersiononeURL".  

Step 2. After an Issue has been created in JIRA and integrated with V1, open the Issue in JIRA and inspect the Custom field for the V1 URL.  
Step 3. Click on that URL.  
>Expected result: The created Defect or Story opens in V1.  


### Test Case 5: Configure VersionOne  
*Assumption: You are not using the V1 Team Edition*  

Step 1. Add "JIRA" to the V1 Global Source list.  
>Expected result: Navigating to Administration -> List Types -> Global tab and viewing the Source table, JIRA should be an entry in that table.  

### Test Case 5A: JIRA identifier in V1 Reference field.  

By default, the integration will place the JIRA identifier in the V1 Reference field.  
Step 1. After an Issue has been created in JIRA and integrated with V1, inspect the corresponding V1 asset reference field for the JIRA identifier.  
>Expected result: The JIRA identifier value is visible in the V1 Reference field.

Step 2. Confirm the value in the V1 asset Reference field matches the JIRA identifier.  


### Test Case 5B: JIRA identifier in V1 Custom field.  
Step 1. Create a Custom field called JiraId in V1 for the JIRA identifier.  
Step 2. After an Issue has been created in JIRA and integrated with V1, inspect the corresponding V1 asset Custom field (e.g. JiraId) for the JIRA identifier.  
>Expected result: The JIRA identifier value is visible in the V1 Custom field.  

Step 3. Confirm the value in the V1 Custom field matches the JIRA identifier.
>Expected result: The value in the V1 JiraId matches the JIRA identifier.

### Test Case 6: Configure the V1 Integration  

Step 1. Run the ServiceHostConfigTool.exe; this should open in a window starting with a General Tab.  
Step 2. On the General Tab, specify your V1 connection details then click the Validate button.  
>Expected result: A message in green type will appear to the far left of the Validate button confirming that "VersionOne settings are valid".  

Step 3. In the tab tree on the left section of the window, select Workitems. 
>Workitems tab appears.  

Step 4. Specify the V1 field that will be storing the JIRA identifier; the default is the V1 Reference field.  
>Expected result: Reference Field Name should be set to Reference and the Disabled checkbox should remain unchecked.  

Step 5. In the tab tree on the left, select JIRA.  
>Expected result: JIRA tab should appear with two of it's own tabs labeled "JIRA Service Settings" and "Project and Priority Mappings" respectively.  

Step 6. On the "JIRA Service Settings" tab, complete Connection field leaving the "/rest/api/latest" part of the url as is as the end of your JIRA URL.  Complete the Username and Password fields in the section as well.  Click the Validate button.  
>Expected result: You should see a "Connection settings are valid. Please, check priority mappings." message in green type appear to the left of the Validate button.  

Step 7A. Still on the "JIRA Service Settings" tab, complete the VersionOne Workitem attributes section.  For Source you see JIRA in the dropdown list; select it.  
>Expected result: JIRA is selected as the Source.  

Step 7B. URL Template should be completed using your JIRA connection URL leaving the "/browse/#key#" part of the sample URL as is.  
Step 7C. URL Title should be completed with a JIRA instance name of your choice.  

Step 8. Poll Interval should be set to the number of minutes you would like the V1 integration to wait before checking for newly created JIRA Issues or closed Assets in V1.  

Step 9A. Still on the "JIRA Service Settings" tab, complete the Find JIRA Issues section.  The Create Defect Filter ID can be found in JIRA by running your desired JIRA Bugs Saved Filter and looking in your browser URL address field for the ?filter=10300 (sample id here).  

Step 7. Map JIRA and V1 Project values.
>Expected result: Available V1 projects should appear in the left drop down list, JIRA products need to be entered manually.  Make sure to match the JIRA product name and spacing exactly as it appears in JIRA.  

Step 8. Map JIRA and V1 Priority values.  
>Expected result: Available V1 priority values should appear in the left drop down list, JIRA priority values should appear in the right drop down list.  Make sure to enter all JIRA priority values that will be utilized noting that a JIRA priority may map to more than one V1 priority. 

Step 9. Click the save icon in the upper left and exit the ServiceHostConfigTool.
>Expected result: You may get prompted to save changes upon exiting the tool, you can save again by clicking "Yes" and you will get prompted to rename or overwrite the existing config file.  DO NOT rename the config file, simply click the save button again and replace the existing file. This will just resave the same settings.  If you click "No" upon exiting the application, the tool will simply close and your saved changes will remain.  

### Test Case 7: Start the Integration  

Step 1. Now that all components have been configured, start the integration by navigating to your installation folder and double-click the VersionOne.ServiceHost.exe.  
>Expected result: A command window will open and display several [Info] messages followed by a [Startup] message. The integration will then begin polling JIRA new bugs and V1 for closed bugs and display information pertaining to the polling results in this window.  

### Test Case 8: Test the Integration  

Step 1. Make sure the Integration is running, JIRA is open, and your instance of VersionOne is open.  
Step 2. Create a new bug in JIRA:  
Step 2 A - Assigned. If using the Assigned method, make sure the new bug is assigned to the person or persons specified in the Saved Filter created in JIRA.  
>Expected result: After creating the new bug, execute the Assigned Bugs Saved Filter and ensure that the newly created bug appears in the Filter results.  

Step 2 B - Tagged. If using the Tagged method, make sure the VersionOne Defect State is set to the "Create Field Value" specified in the ServiceHostConfigTool and submit the bug.  
>Expected result: After creating the new bug, execute the Tagged Bugs Saved Filter and ensure that the newly created bug appears in the Filter results.  

Step 3. Check V1 for your newly created JIRA Bug by viewing the specified V1 Project Backlog.  
>Expected result: If all is set up correctly, you should see your JIRA bug appear in the V1 Project Backlog set to the appropriate mapped priority after the specified polling time interval that was set in the ServiceHostConfigTool. 

Step 4. Check JIRA for an updated Status of your new bug.  
>Expected result: The JIRA bug should now have a status of IN_PROGRESS as it was updated by the Integration. 

Step 5. Close the defect in V1.  
>Expected result: The V1 defect should now appear closed in V1 and, after the specified polling time, that same bug should appear as closed in JIRA.


