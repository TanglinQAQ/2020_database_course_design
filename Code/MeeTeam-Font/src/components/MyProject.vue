<template>
  <div id="deleteteam-container">
   <el-main>
          <el-table :data="tableData" :default-sort="{ prop: 'date', order: 'descending' }">
            <el-table-column prop="projectname" label="项目名称" width="140">
            </el-table-column>
            <el-table-column prop="originator_id" label="组队发起人" width="140">
            </el-table-column>
            <el-table-column prop="team_type" label="项目类型" width="140">
            </el-table-column>
            <el-table-column prop="region" label="所在校区" width="200">
            </el-table-column>
            <el-table-column prop="details" label="项目简介" width="400">
            </el-table-column>
            <el-table-column prop="date" label="发布时间" sortable>
            </el-table-column>
          </el-table>
          
        </el-main>
         
         </div>
</template>

<script>
export default {
  name: 'MyProject',
}
</script>

<style>

</style>