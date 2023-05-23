const options: Highcharts.Options = {
    chart: {
      type: 'column',
    },
    subtitle: {
      text: 'Source: http://dados.recife.pe.gov.br/dataset/despesas-orcamentarias',
    },
    xAxis: {},
    yAxis: {
      title: {
        text: 'Valor liquido total',
      },
    },
    tooltip: {
      headerFormat:
        '<span style="font-size:10px">{point.key}</span><table>',
      pointFormat:
        '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
        '<td style="padding:0"><b>{point.y:.2f}</b></td></tr>',
      footerFormat: '</table>',
      shared: true,
      useHTML: true,
    },
    plotOptions: {
      column: {
        pointPadding: 0.2,
        borderWidth: 0,
      },
    },
    series: [],
  };

  export {options}